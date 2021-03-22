import 'package:flutter/material.dart';
import 'dart:async';
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'dart:math';

void main() => runApp(MiApp());

Random random = new Random();
int randomNumber = random.nextInt(100);

class MiApp extends StatelessWidget {
  const MiApp({Key key}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: "Mi App",
      home: Inicio(),
    );
  }
}

class Inicio extends StatefulWidget {
  Inicio({Key key}) : super(key: key);
  @override
  _InicioState createState() => _InicioState();
}

class _InicioState extends State<Inicio> {
//creando sendData
  Future<String> sendData() async {
//generar num random
    //numero aleatorio de 1 a 100
    var response = await http.post(
        Uri.encodeFull(
            "https://apidoblesarah.azurewebsites.net/api/data"), //v13 no lo soporta
        headers: {"Content-type": "application/json"},
        body: jsonEncode(<String, String>{
          "datetime": "2021-03-16T20:00:00",
          "random": randomNumber.toString()
        }));
    print(response.body);
    return "Success!!";
  }
//Activar el http

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Mi App Sarah"),
      ),
      body: Center(
          child: new ElevatedButton(
              onPressed: sendData,
              child: new Text("Enviar" + randomNumber.toString()))),
    );
  }
}
