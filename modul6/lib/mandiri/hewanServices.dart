import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:modul_6/mandiri/hewanModel.dart';

class HewanService {
  static const String _dogUrl = "https://dog.ceo/api/breeds/image/random";

  Future<Hewan> getRandomHewanImageUrl() async {
    final response = await http.get(Uri.parse(_dogUrl));

    if (response.statusCode == 200) {
      final data = jsonDecode(response.body);
      return Hewan(imageUrl: data["message"]);
    } else {
      throw Exception("Failed to load hewan image");
    }
  }
}
