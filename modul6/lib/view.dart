import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:modul_6/modelApi.dart';
import 'package:modul_6/services.dart';
import 'package:http/http.dart' as http;

class ProductView extends StatelessWidget {
  const ProductView({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.red,
        title: const Text(
          "Product",
          style: TextStyle(color: Colors.white),
        ),
      ),
      body: FutureBuilder(
        future: Service().getProducts().catchError((value) {
          ScaffoldMessenger.of(context)
              .showSnackBar(SnackBar(content: Text(value.toString())));
          return <Product>[];
        }),
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(
              child: CircularProgressIndicator.adaptive(),
            );
          }
          if (snapshot.connectionState == ConnectionState.done &&
              snapshot.hasData) {
            final products = snapshot.data!;
            return ListView.builder(
              padding: const EdgeInsets.symmetric(vertical: 10),
              itemCount: products.length,
              itemBuilder: (context, index) => ListTile(
                minVerticalPadding: 24,
                visualDensity: VisualDensity.adaptivePlatformDensity,
                leading: Image.network(
                  products[index].thumbnail,
                  fit: BoxFit.cover,
                  width: 100,
                  errorBuilder: (context, error, stackTrace) {
                    return Icon(Icons.error, color: Colors.red);
                  },
                ),
                title: Text(products[index].title),
                trailing: CircleAvatar(
                  radius: 24,
                  backgroundColor: Colors.red,
                  child: Text(
                    "\$${products[index].price}",
                    style: const TextStyle(color: Colors.white),
                  ),
                ),
              ),
            );
          }
          return const SizedBox();
        },
      ),
    );
  }
}
