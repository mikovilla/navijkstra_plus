let map;
let polyline;
let markers = [];
let coordLat;
let coordLong;

window.initializeMap = function (lat, lng) {
    console.log("Initializing map at:", lat, lng);
    map = L.map('map').setView([lat, lng], 2);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: 'Map data © OpenStreetMap contributors'
    }).addTo(map);
};


window.drawPath = function (pathCoordinates) {
    console.log("Received pathCoordinates:", JSON.parse(pathCoordinates));

    if (polyline) {
        map.removeLayer(polyline);
    }
    markers.forEach(marker => map.removeLayer(marker));
    markers = [];

    if (!Array.isArray(JSON.parse(pathCoordinates))) {
        console.error("pathCoordinates is not an array");
        return;
    }

    console.log("Valid coordinates received:", pathCoordinates);
    polyline = L.polyline(JSON.parse(pathCoordinates), { color: 'red' }).addTo(map);

    JSON.parse(pathCoordinates).forEach(coord => {
        const marker = L.circleMarker(coord, {
            radius: 5, 
            color: 'red', 
            fillColor: 'black', 
            fillOpacity: 1 
        }).addTo(map);
        markers.push(marker); // Keep track of the marker
        console.log("Dot added at:", coord);
    });
    coordLat = JSON.parse(pathCoordinates)[0][0];
    coordLong = JSON.parse(pathCoordinates)[0][1];
    map.setView([coordLat, coordLong], 15);
};

