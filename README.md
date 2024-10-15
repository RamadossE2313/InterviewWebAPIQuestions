## Features
- **CQRS Pattern**: Separation of commands and queries to ensure clear boundaries between reading and writing data.
- **Rate Limiting**: Protects the API from abuse by limiting the number of requests a client can make in a given period.
- **HTTP Verbs**: Proper use of `GET`, `POST`, `PUT`, and `DELETE` for resource manipulation.
- **Unit Testing**: Comprehensive unit tests using **xUnit** to ensure code correctness.
- **Integration Testing**: End-to-end testing of the API using **SpecFlow** for behavior-driven development.

## Technologies
- **ASP.NET Core**: For building the Web API.
- **MediatR**: For implementing CQRS pattern.
- **xUnit**: For unit testing.
- **SpecFlow**: For integration and behavior-driven testing.
- **Rate Limiter**: Middleware to throttle API requests.
