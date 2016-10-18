# Adrestia

## Git Helper
- Check status: ```git status```
- Fetch remote changes: ```git fetch```
- Make new branch: ```git branch <branch_name>```
- Switch to a branch: ```git checkout <branch_name>```
- Update branch: ```git pull origin/<branch_name>```
- Add changes to a commit: ```git add <file_path>``` or ```git add .``` to add all changes
- Commit changes: ```git commit -m "<commit_message>"```
- Push commits: ```git push origin <branch_name>```
- Revert to last commit: ```git reset --hard HEAD```

## Workflow
- ```git fetch``` & ```git status``` to check current state of the remote
- ```git add <file_path>``` to add a file to the commit. ```git add .``` to add all changes to your commit
- ```git commit -m "<commit_message>"``` to make a new commit
- ```git push origin <branch_name>``` to push your commit to the remote branch
