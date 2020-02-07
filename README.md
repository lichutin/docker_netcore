# docker_netcore

build: docker build -f RabbitDocker/Dockerfile -t lichutinmodul/firstdotnet .

run:  docker run -it --rm -p 30080:80 lichutinmodul/firstdotnet
