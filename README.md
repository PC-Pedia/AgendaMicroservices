# Agenda Microservices
Project to learn how to create a microservice architecture from scratch using simple components.

## Iteration-1

- Only one service with local database access.

- To add a new contact: ` curl -i -X POST -H "Content-Type:application/json" http://localhost:51242/api/contacts -d '{"Name":"Me", "Email":"me@server.com"}'`
