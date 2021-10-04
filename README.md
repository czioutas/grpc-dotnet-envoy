# grpc-dotnet-envoy

# GrpcServer
The actual implmentation of the remote procedure calls

The GrpcServer also supports normal controller endpoints (alternative to using grpc-web with envoy)

# GrpcClient
An implementation of the GRPC client in c#

# GrpcWebClient
An implementation of the GRPC client in JS

# Envoy
Envoy is a reverse proxy with full support for GRPC. this is due to the need to translate http/1 to http/2 when calling from web (js)
