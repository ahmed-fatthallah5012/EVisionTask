# EVision Task

Database hierarchy 
  Customer 
      int Id => CustomerId
      string name => CustomerName
      string address => CustomerAddress
  Vehicle
      string Id => VehicleId
      string register Plate => RegisterNumber
      bool status => ShowStatus
Software hierarchy
  Domain Model
      EF Models & Configuration=> Models
      Migrations for DB => Migrations
      Repository Pattern => Respositories
  Model
      Models for API => Models
      Filters for filter models => Filters
  Core
      Any logic we want to do not need Database and do excute Actions in Repositories
      Configuration => Configurations
          for mapping between Models & Domain Model => MappingProfile
      Service =>  for the logic
  Server
      Contain Api Controllers and Work for Ping Vehicles
      Server API : https://localhost:5001
  Client
      Contain Angular Project on http://localhost:4200  
