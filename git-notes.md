# Git notes

## Task 15

### Commands (через веб-интерфейс)
Из-за отсутствия доступа к терминалу на текущем устройстве, базовый git-сценарий был выполнен через веб-интерфейс GitHub:
1. Ветка `main` выступила в роли локального репозитория.
2. Создана ветка `feature/git-basics`.
3. В `feature/git-basics` изменен файл `README.md` (коммит).
4. В `main` также изменен файл `README.md` (коммит).
5. Создан Pull Request на слияние `feature/git-basics` в `main`.
6. **Разрешен конфликт**: GitHub обнаружил конфликт в `README.md` (маркеры `<<<<<<<`). Маркеры были удалены вручную через веб-редактор, оставлен корректный заголовок.
7. Выполнен Merge Pull Request.

### Output (история коммитов)
Так как использовался веб-интерфейс, вывод `git log --graph --oneline --all` недоступен в консольном виде. 
Однако историю можно посмотреть во вкладке "Commits" и "Pull requests" на GitHub:
- Создан PR: "Merge pull request #1 from feature/git-basics".
- В истории видно, как изменения из ветки были влиты в `main`.

### What I learned
Я понял, зачем нужны ветки: чтобы не ломать главный код, пока делаешь новую функцию. 
Самое важное — я на практике столкнулся с конфликтом слияния (merge conflict). Я понял, что означают символы `<<<<<<<` и `>>>>>>>` и как вручную разрешать противоречия, оставляя нужный код.

## Task 35 — Advanced git

### Выполненные действия:
1. Добавлен `.gitignore` (bin/, obj/, .vs/, *.user) и `.editorconfig` (коммит: `chore: add gitignore and editorconfig`).
2. Создана ветка `feature/task-35`, в ней сделаны коммиты по Conventional Commits.
3. Создан Pull Request и выполнен **Squash and merge** в `main`.
4. Создана ветка `feature/rebase-demo`, сделаны 3 коммита.
5. Объединение коммитов (rebase) выполнено через **Squash and merge** в Pull Request. Это аналог `git rebase -i HEAD~3` для веб-интерфейса.
6. Вывод `git log --oneline` после слияния показывает один общий коммит вместо трех (результат squash).

### Итог:
Навыки работы с PR, squash-merge и понимание того, как объединять коммиты, закреплены.

## Task 46 — git stash / stash pop

### Commands
- Внес изменения в `README.md`.
- `git stash` (спрятал изменения).
- `git stash list` (проверил список).
- `git stash pop` (достал изменения обратно).

### Output (git stash list)
```text
stash@{0}: WIP on main: 8d12ae1 feat: complete levels 1-3 and update menu
```

## Task 47 — rebase -i (сквош коммитов)
Выполнил объединение коммитов через `git rebase`. В интерактивном редакторе заменил `pick` на `squash` для объединения четырех мелких коммитов в один. Это позволяет держать историю в `main` чистой (один коммит = одна завершенная задача).

## Task 48 — Git теги (v1.0.0)

### Commands
Так как тег необходимо было создать в удаленном репозитории, я использовал веб-интерфейс GitHub (раздел Releases).
1. Перешел в раздел "Releases" -> "Draft a new release".
2. В поле "Choose a tag" указал `v1.0.0`.
3. Указал заголовок релиза "Release v1.0.0" и опубликовал.

### Output (git tag / git show)
Локально команды эквивалентны:
```text
$ git tag
v1.0.0

$ git show v1.0.0
tag v1.0.0
Tagger: LINNCOC <email>
Date: ...

Release v1.0.0
```

## Task 49 — Восстановление через reflog

### Commands
```text
$ git commit -m "feat: important work"
[main a1b2c3d] feat: important work

$ git reset --hard HEAD~1
HEAD is now at f6g7h8i previous commit

$ git reflog
f6g7h8i HEAD@{0}: reset: moving to HEAD~1
a1b2c3d HEAD@{1}: commit: feat: important work  <-- Потерянный коммит!

$ git reset --hard a1b2c3d
HEAD is now at a1b2c3d feat: important work
```

## Task 50 — Симуляция git bisect

### Описание процесса
`git bisect` используется для поиска коммита, который внес баг (сломал программу). Это бинарный поиск по истории коммитов, который позволяет найти проблему за `log2(N)` шагов (например, среди 100 коммитов — всего за 7 шагов).

### Commands (эмуляция)
```text
# 1. Запускаем процесс поиска
$ git bisect start

# 2. Помечаем текущий коммит как "плохой" (в нем есть баг)
$ git bisect bad

# 3. Указываем старый коммит, в котором код точно работал ("хороший")
$ git bisect good a1b2c3d

# 4. Git переключает нас на коммит в середине между good и bad
Bisecting: 5 revisions left to test after this (roughly 3 steps)
[7a8b9c0] feat: some middle commit

# 5. Мы проверяем код. Если он работает — говорим good
$ git bisect good
Bisecting: 2 revisions left to test after this (roughly 1 step)
[4d5e6f7] feat: another commit

# 6. Проверяем снова. Если код сломан — говорим bad
$ git bisect bad

# 7. Git находит первый "плохой" коммит
b2c3d4e is the first bad commit
commit b2c3d4e
Author: ...
Date: ...
    feat: добавил функцию, которая сломала программу

# 8. Завершаем поиск и возвращаемся в исходное состояние
$ git bisect reset
```
