# BookStore
## A simple .Net Core bookstore with a clean architecture and DDD approach, using CQRS.

### Note 1:
In this project, two existing entities, Book and Author, are supposed to be aggregate roots, following the idea that says an object belongs to an aggregate if there isn't any reason for that object to stay alive after deleting the aggregate root.

### Note 2:
Following DDD principles, repositories should only create for aggregate roots. For example, having a BookVisitorReview or BookComment entity, because they belong to Book aggregate, all of their CRUD operations will be handled by IBookRepository.

### Note3
You can check the APIs by running the BookStore.Api as the startup project and considering Swagger UI.
