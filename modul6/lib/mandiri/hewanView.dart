import 'package:flutter/material.dart';
import 'package:modul_6/mandiri/hewanModel.dart';
import 'package:modul_6/mandiri/hewanServices.dart';

import 'package:flutter/material.dart';

class HewanList extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Foto anjing random"),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            ElevatedButton(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => DogPage()),
                );
              },
              child: Text("Anjing"),
            ),
            SizedBox(height: 20),
          ],
        ),
      ),
    );
  }
}

class DogPage extends StatefulWidget {
  @override
  _DogPageState createState() => _DogPageState();
}

class _DogPageState extends State<DogPage> {
  late Hewan _hewan;
  bool _isLoading = true;

  @override
  void initState() {
    super.initState();
    _fetchDogImage();
  }

  Future<void> _fetchDogImage() async {
    final service = HewanService();
    final hewan = await service.getRandomHewanImageUrl();
    setState(() {
      _hewan = hewan;
      _isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Dog Page"),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            _isLoading
                ? CircularProgressIndicator()
                : Image.network(
                    _hewan.imageUrl,
                    width: 300,
                    height: 300,
                  ),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: _fetchDogImage,
              child: Text("Refresh Gambar"),
            ),
          ],
        ),
      ),
    );
  }
}
