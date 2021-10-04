const {HelloRequest, HelloReply} = require('./GrpcServer/Protos/greet_pb.js');
const {GreeterClient} = require('./GrpcServer/Protos/greet_grpc_web_pb.js');

var client = new GreeterClient('https://localhost:5001');

var request = new HelloRequest();
request.setName('World');

client.sayHello(request, {}, (err, response) => {
    console.log(err);
    console.log(response.getMessage());
});