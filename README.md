# HackAndChangeApi

## Запуск 

```
docker build -t YourName
docker run YourName
```

## Entry point


### Auth
https://localhost:{port}/auth/auth - аунтификаиця, требует 2 параметра login и password и выдаёт аунтифицированного пользователя или пишет что он не найдет </br>
https://localhost:{port}/auth/verify - верефицирует jwt токен(и требует его в параметры) пользователя, если такой пользователь есть, она вернёт его или скажет что его нет </br>
https://localhost:{port}/auth/registration - добавляет нового пользователя по полученным логину и паролю </br>

### User
https://localhost:{port}/user/info - принимает userId. По полученному айдишнику выдаёт информацию о пользователе если тот существует </br>
https://localhost:{port}/user/info - принимает новые данные о пользователе, ищет его в базе данных и если тот существует меняет информацию о нём </br>

### Share
https://localhost:{port}/share/create - принимает новую акцию и добавляет её в базу данных </br>
https://localhost:{port}/share/get - без параметров возвращает список всех акций </br>
https://localhost:{port}/share/get - принимает shareId и возвращает акцию если та существует </br>
https://localhost:{port}/share/update - принимает новые данные о акции, ищет её в базе данных и если та существует меняет информацию о ней </br>
https://localhost:{port}/share/delete - принимает shareId, ищет обьект share в базе данных и если тот существует удаляет её </br>

### Media
https://localhost:{port}/media/create - принимает новые медиа и добавляет их в базу данных </br>
https://localhost:{port}/media/get - без параметров возвращает список всех медиа </br>
https://localhost:{port}/media/get - принимает mediaId и возвращает медиа если они существует </br>
https://localhost:{port}/media/update - принимает новые данные о медиа, ищет их в базе данных и если те существует меняет информацию о них </br>
https://localhost:{port}/media/delete - принимает mediaId, ищет обьект media в базе данных и если тот существует удаляет её </br>
