### What does each command do?
- ```git checkout``` switches the working directory to a different branch, or rolls it back to a certain commit. It's also used to restore specific files from another branch/commit.
- ```git cherry-pick``` applies a specific commit from another branch without merging the whole branch. Its concept is similar to staging but for whole commits.
- ```git log``` shows commit history in the current branch.
- ```git blame``` shows who modified each line in a file and when.

### When would you use it in a real project?
- ```git checkout``` can be used to undo mistakes in managing files within a project.
- ```git cherry-pick``` can be used to bring over commits that fix certain problems or add features from other branches that haven't been merged into main yet into another branch.
- ```git log``` is used to view commit history and see how the project is evolving.
- ```git blame``` can be used to see who wrote what in certain files and attribute these changes/"pin the blame" on them.

### What surprised you while testing these commands?
I was surprised at how much control you can have over commits and branches with these commands, especially with ```git cherry-pick```.

### Images
Using ```git checkout```:
![Test1](/issues/_images/Advanced_Git_001.jpg)

Using ```git cherry-pick``` to bring over ```Create advanced1.txt``` into ```main```:
![Test2](/issues/_images/Advanced_Git_002.jpg)
![Test3](/issues/_images/Advanced_Git_003.jpg)
![Test4](/issues/_images/Advanced_Git_004.jpg)

Using ```git log```:
![Test5](/issues/_images/Advanced_Git_005.jpg)

Using ```git blame```:
![Test6](/issues/_images/Advanced_Git_006.jpg)