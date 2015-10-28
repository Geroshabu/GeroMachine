git clone --branch=gh-pages https://github.com/Geroshabu/Geroshabu.github.io.git C:\projects\gh-pages
cd C:/projects/gh-pages
if exist html (rd html /s /q)
doxygen C:/projects/GeroMachine/Doxyfile
if exist latex (rd latex /s /q)
cd html
git status | findstr /C:"Changes not staged for commit:" /C:"Untracked files:"
if Not ERRORLEVEL 1 (
    git add --all .
    git commit -m "auto commit doxygen products by AppVeyor" -m %APPVEYOR_REPO_COMMIT%
    git push
)

