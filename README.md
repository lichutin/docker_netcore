# k8s usage

Create a local docker registry
```
docker create -p 5000:5000 --restart always --name registry registry:2
docker start registry
```

Fill it with docker images

```
docker build -f RabbitDocker/Dockerfile -t lichutinmodul/firstdotnet .
docker tag lichutinmodul/firstdotnet localhost:5000/lichutinmodul/firstdotnet
docker push localhost:5000/lichutinmodul/firstdotnet

docker build -f Generator/Dockerfile -t lichutinmodul/generator .
docker tag lichutinmodul/generator localhost:5000/lichutinmodul/generator
docker push localhost:5000/lichutinmodul/generator
```

Create a k8s deployment

```
kubectl create -f k8s-deploy.yaml
```

Forward a port

```
kubectl port-forward firstdotnet-66d446889b-4hgqj 30082:80
```

And open an url in a browser
http://localhost:30082/speaking/get — Example of pods' communication

