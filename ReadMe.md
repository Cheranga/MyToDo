# Notes

## Plan

### Startup
- [x] Create an blank solution (MyToDo).
- [x] Create an Azure functions project (MyToDo.Functions).
- [x] Create a class library to manage the request/response classes.
- [ ] Create class libraries for separate data access projects,
  - [x] MyToDo.DataAccess.TableStorage
  - [ ] MyToDo.DataAccess.Cosmos
  - [ ] MyToDo.DataAccess.Sql (Do this one's implementation as the last implementation)
 
- [x] Create a GIT repository in github and publish the code changes.


### Table Storage

- [x] Table storage related function implementations.
- [x] Run the project locally and test the API functionality using postman.
- [x] Create an Azure Function App in the portal.
- [x] Deploy the solution using VS publish option to this function and test it's functionality.
- [x] Test the deployed functions in Azure using postman.

### Cosmos

- [ ] Cosmos database related implementations.
- [ ] Run the project locally and test the API functionality using postman.
- [ ] Deploy the changes to the same Azure function app in the portal.
- [ ] Test the deployed functions in Azure using postman.

## DevOps

- [ ] Create a new project in Azure DevOps.
- [ ] Create a CI pipeline to build the application.
- [ ] Create a CD pipeline to use the build artifact and deploy in the function app created in the portal.
- [ ] Test the deployed functions in Azure using postman.

## CI/CD
- [ ] Enable CI/CD in the build and release pipelines.
- [ ] Do a code change and commit the code and, test whether the CI/CD works fine. This should be done after the CD step is completed.