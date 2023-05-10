# CatHome

This is a CatHome web API where members can find and adopt cats. 
The members can view all cats and submit an application and track applications status for now.

## Instructions:
1. Open the CatHome.sln
2. Run the app by pressing the green play button on top in visual studio
3. Test the endpoints in swagger
or test in frontend: 
4. Open CatHome.Web in visual studio code
5. Enter npm run dev in terminal
6. Go to the presented url - make sure backend run.

# Documentation
Based on the requirements from client my goals where:
- Making it possible to apply for an adoption of a cat.
- Making the API easily maintained and easy to update in the future. Thinking sepereration of concerns.

To achieve this goals I used a layered architecture. 
- Domain layer, contains the entities and abstract classes that represent the business logic of the application.
- Infrastructure layer, contains the implementations of the domain layer repository interfaces.
- Web API layer, A RESTful API interface for clients to interact with the application.

- I added an adoptionapplication class and store it in a json file when a application is made.
- The adoption application status is set to pending by default, but I added methods where rules and logic for updating the status will be made, same with if it needs approval by another member.

What I could have done if I had more time:
- Validations and rules could be added to the domain layer to meet the requirements for adopting a cat.
- Mapping and validation classes could be added for further seperation of concerns and make it more maintainable.
- Additional API endpoints should be added, such as get a members adoption application by id.
- Focus on frontend - give structure, add enum for application status, make reusable components and hooks, error handling and style.

# API Endpoints
GET/api/cats - Gets all cats
POST/api/adoptionapplications - Applies for adoption of a cat by a member
GET/api/applications - Gets all adoption applications

# Education
C#