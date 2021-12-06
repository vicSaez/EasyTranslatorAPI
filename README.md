# EasyTranslatorAPI
Test .Net Core 3.1 Project that translate sentences using google translator unofficial API

How to run:

1) Clone repo.
2)  docker build -f .\EasyTranslatorAPI\Dockerfile -t easytranslatorapi:1 .
3)  docker run -it --rm -p 49155:80 easytranslatorapi:1
4)  You can access swagger at http://localhost:49155/swagger
