## generate clients

on dir GrpcTest execute
`protoc GrpcServer/Protos/greet.proto --js_out=import_style=commonjs,binary:GrpcWebClient --grpc-web_out=import_style=commonjs,mode=grpcwebtext:GrpcWebClient` to generate the JS client against the greet.proto