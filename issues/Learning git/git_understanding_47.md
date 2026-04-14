### Why is pushing directly to main problematic?
The main branch is typically the production/stable branch of the project, i.e. the version of the project that will be shipped out to the public. It shouldn't be treated as an experimental branch. It's also the one new branches branch out from the most. Pushing commits to main, especially faulty ones, might introduce a cascading effect where other branches inherit those faults, making fixing them more troublesome.

### How do branches help with reviewing code?
Branches help isolate changes, making it easier for reviewers to compare code and spot potential problems without affecting the main branch.

### What happens if two people edit the same file on different branches?
Nothing happens. These two branches hold different, separate versions of the file; one change made in one branch doesn't carry over to any other branch. There will only be problems once these two branches are both being pulled into main as that would create a merge conflict.

Images:
![Test1](/issues/_images/Branching_001.jpg)
![Test2](/issues/_images/Branching_002.jpg)
![Test3](/issues/_images/Branching_003.jpg)