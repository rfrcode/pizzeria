const express = require('express')
const bodyParser = require('body-parser');
const app = express();
const upload = require('multer')()
//app.use(bodyParser.json());
app.post('/images',upload	.any(),(req,res)=>{
  
  res.end(JSON.stringify([
    'url1',
    'url2',
    'url3',
    'url4',
  ]));
})

app.listen(3000, function () {
  console.log('¡Puerto 3000 abierto!');
})