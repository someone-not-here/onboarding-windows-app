### What does git bisect do?
```git bisect``` is a Git command that does a binary search through a repo's commit history in order to find a culprit commit responible for introducing a certain bug. 

It's done by specifying first a *good* commit through the command ```git bisect good <rev>```, which is a commit that you know doesn't have the bug -- this serves as the floor for the search range. The latest commit which has the bug, known as a *bad* commit, is then typically used as the ceiling for the search range, specified through the command ```git bisect bad <rev>```.

```git bisect``` will now automatically choose a commit for the developer to build and test. If the particular build still has the bug, then the developer specifies the commit is *bad* through the same command as above, and vice versa. This repeats until the search is narrowed down to a single commit.

### When would you use it in a real-world debugging situation?
It's used when a bug is found yet no one knows which commit introduced it. Big projects would have hundreds or even thousands of commits, so finding the culprit commit manually can be a pain. ```git bisect``` somewhat automates this process and cuts down on the number of commits developers would have to build and test exponentially.

### How does it compare to manually reviewing commits?
```git bisect``` somewhat automates the process and cuts down on the number of commits developers would have to build and test exponentially. Compared to manual review, it's much faster and more efficient.

#### Images
Series of commits. Commit 4 has the "bug".
![Test1](/issues/_images/Bisect_001.jpg)

```git bisect``` process.
![Test2](/issues/_images/Bisect_002.jpg)