if "%APPVEYOR_PULL_REQUEST_NUMBER%"=="" (
    git config --global user.email %MailAddress%
    git config --global user.name %UserName%
    git config --global push.default matching
    if "%APPVEYOR_REPO_BRANCH%"=="master" (
        git clone --quiet --branch=gh-pages https://github.com/Geroshabu/GeroMachine.git C:\projects\gh-pages
        cd C:/projects/gh-pages
        if exist html (rd html /s /q)
        doxygen C:/projects/GeroMachine/Doxyfile
        if exist latex (rd latex /s /q)
        cd html
        git add --all .
        git commit -m "auto commit doxygen products by AppVeyor" -m %APPVEYOR_REPO_COMMIT%
        git push --quiet https://%GitHubAccessToken%@github.com/Geroshabu/GeroMachine gh-pages
    ) else if "%APPVEYOR_REPO_BRANCH%"=="develop" (
        git clone --quiet --branch=gh-pages https://github.com/Geroshabu/GeroMachine.git C:\projects\gh-pages
        cd C:/projects/gh-pages
        if exist html (rd html /s /q)
        doxygen C:/projects/GeroMachine/Doxyfile
        if exist latex (rd latex /s /q)
        cd html
        git add --all .
        git commit -m "auto commit doxygen products by AppVeyor" -m %APPVEYOR_REPO_COMMIT%
        git push --quiet https://%GitHubAccessToken%@github.com/Geroshabu/GeroMachine gh-pages
    )
)
