# Warthog.Api
A .NET Core API to fetch dummy data of a magical nature

Used in this project:
 - .NET Core 3.1
 - MongoDB
 - Serilog
 - xUnit
 - Moq
 
 ## Endpoints
 
 ### GET `/students`
 
 | param |  type  | description | default |
 |-------|--------|-------------|---------|
 | count | number | Desired number of students returned | 20 |
 
Example:

GET `/students?count=10`

```
[
  {"id":"687801bc-e902-47df-98af-4b55aca0f858","firstName":"Rubeus","lastName":"Granger","gpa":6,"house":"slytherin"},
  {"id":"02a09cfb-f9bf-45f9-ad1d-616f56b975fa","firstName":"Susan","lastName":"Longbottom","gpa":2,"house":"ravenclaw"},
  {"id":"dea37756-ccb1-4cde-a033-60f82455adc1","firstName":"Neville","lastName":"Malfoy","gpa":8,"house":"ravenclaw"},
  {"id":"5854f001-92c0-4a6d-96b3-20105a78c04c","firstName":"Millicent","lastName":"Lovegood","gpa":1,"house":"hufflepuff"},
  {"id":"03c6995e-d31f-4b72-9203-dd646c5c58d1","firstName":"Cho","lastName":"Hagrid","gpa":4,"house":"hufflepuff"},
  {"id":"c1cab3bc-2547-45d7-b854-229aafe392b2","firstName":"Cho","lastName":"Malfoy","gpa":5,"house":"ravenclaw"},
  {"id":"13a4e479-e2f3-457f-8b15-faf4a5c579fd","firstName":"Harry","lastName":"Lovegood","gpa":9,"house":"ravenclaw"},
  {"id":"f263440f-775d-4291-9f87-8b76bf849da1","firstName":"Harry","lastName":"Lovegood","gpa":1,"house":"ravenclaw"},
  {"id":"c31b656c-62cc-4297-9753-80e0ecdeef54","firstName":"Ron","lastName":"Longbottom","gpa":7,"house":"slytherin"},
  {"id":"aeb8a194-b4a4-48b9-8015-ddca9e3ccfeb","firstName":"Millicent","lastName":"Malfoy","gpa":3,"house":"gryffindor"}
]
```

### GET `/students/{id}`

Example:

GET `/student/687801bc-e902-47df-98af-4b55aca0f858`

```
{
  "id":"687801bc-e902-47df-98af-4b55aca0f858",
  "firstName":"Hermione",
  "lastName":"Granger",
  "gpa":9,
  "house":"gryffindor"
}
```

## Still to do 

 - Add more tests - xUnit and Cypress
 - Finish subjects endpoint
 - Add pagination for larger payloads
 - Environment variable management
 - Error handling
