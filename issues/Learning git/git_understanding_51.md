### What caused the conflict?
Both main and test-branch-for-issue-#51 branches had commits that changed line 5 in sandbox/commits.txt.

The commit in main had the line: "Wow! Main branch edit!"
The commit in test-branch-for-issue-#51 had the line: "Wow! Test branch edit!"

These changes conflicted with one another upon creating a pull request from test-branch-for-issue-#51 to main.

### How did you resolve it?
I resolved the conflict through "Resolve conflicts" after creating the pull request. This allowed me to review every conflict (in this case, just the one line change) and decide which change from the two branches I want to keep.

Images:
![Test1](/issues/_images/Merge_Conflict_001.jpg)
![Test2](/issues/_images/Merge_Conflict_002.jpg)

### What did you learn?
I learned that in collaborative work -- especially over the Internet -- conflicts changes happen a lot. It's necessary to make sure everyone on the team are on the same page within the project so merge conflicts are minimized.