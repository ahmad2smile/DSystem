# DSystem

Distributed System with communication over RabbitMQ

## Details

Project has 2 Main Services `Cart` & `Suggestions`. When some item is added or remove from Cart, it publishes a message on `cartQueue`.

`Suggestions` service consuming `cartQueue` logs user's actions.

This Async communication pattern is done with **RabbitMQ** using **Mass Transit**.


## Run

1. Run with `docker-compose` to bring all services up
2. Use API Gateway with swagger on `localhost:5000/swagger` to add item to cart
3. Check `cartQueue` on RabbitMQ on `localhost:15672`
4. Observe logs for message

```
User: 2, likes Item: 1
```

```
warn: Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3]
      Failed to determine the https port for redirect.
info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/2 POST http://cart:5001/cart.CartGrpc/AddItem application/grpc -
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[0]
      Executing endpoint 'gRPC - /cart.CartGrpc/AddItem'
dbug: MassTransit[0]
      Create send transport: rabbitmq://rabbitmq/cartQueue
dbug: MassTransit[0]
      Declare exchange: name: cartQueue, type: fanout, durable
dbug: MassTransit[0]
      SEND rabbitmq://rabbitmq/cartQueue 00020000-ac12-0242-4e48-08d8e72b03c1 Cart.AddItemReply
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[1]
      Executed endpoint 'gRPC - /cart.CartGrpc/AddItem'
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished HTTP/2 POST http://cart:5001/cart.CartGrpc/AddItem application/grpc - - 200 - application/grpc 220.7430ms
info: Suggestions.Models.AddItemToCartConsumer[0]
      User: 2, like Item: 1
dbug: MassTransit.ReceiveTransport[0]
      RECEIVE rabbitmq://rabbitmq/cartQueue 00020000-ac12-0242-4e48-08d8e72b03c1 Cart.AddItemReply Suggestions.Models.AddItemToCartConsumer(00:00:00.0077969)
```
