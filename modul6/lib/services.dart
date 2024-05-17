import 'dart:convert';

import 'package:modul_6/modelApi.dart';
import 'package:http/http.dart' as http;

class Service {
  Future<List<Product>> getProducts() async {
    final response =
        await http.get(Uri.parse("https://dummyjson.com/products"));
    if (response.statusCode == 200) {
      final Map<String, dynamic> responseData = jsonDecode(response.body);
      final List<dynamic> productList = responseData['products'];
      List<Product> products = [];
      for (var productJson in productList) {
        products.add(Product.fromJson(productJson));
      }
      return products;
    } else {
      throw Exception();
    }
  }
}
