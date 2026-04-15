### What is the difference between staging and committing?
**Staging** allows you to cherrypick specific changes to be included in the next commit. 

**Committing** saves the currently staged changes permanently to the repository's history as a new commit with a message.

### Why does Git separate these two steps?
It gives developers greater control over what changes are included in each commit, encouraging more focused and cleaner commits. 

### When would you want to stage changes without committing?
- When you want to review your changes before committing.
- When you want to commit only *some* of your changes.
- When you want to split your changes into several, more focused commits. 

### Images
Two changes made:
![Test1](/issues/_images/Staging_001.jpg)

Adding one change to the index:
![Test2](/issues/_images/Staging_002.jpg)

Only one change committed:
![Test3](/issues/_images/Staging_003.jpg)

Resetting that staged change:
![Test4](/issues/_images/Staging_004.jpg)