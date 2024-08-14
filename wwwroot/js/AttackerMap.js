//var map = L.map('map').setView([31.0461, 34.8516], 8); // ישראל
//L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
//    maxZoom: 19,
//}).addTo(map);

var connection = new signalR.HubConnectionBuilder().withUrl("/hub").build();
function SendMissile(model) {
    console.log("נכנס לפונקציית השליחה")
    let src_lat = parseFloat(document.getElementById("source-latitude").value);
    let src_lng = parseFloat(document.getElementById("source-longitude").value);
    let dst_lat = parseFloat(document.getElementById("target-latitude").value);
    let dst_lng = parseFloat(document.getElementById("target-longitude").value);
    connection.invoke("LaunchMissile", JSON.stringify(model), src_lat, src_lng, dst_lat, dst_lng).catch(function (err) {
        return console.error(err.toString());
    });
}

connection.start().then(function () {
    console.log("SignalR connected");
}).catch(function (err) {
    return console.error(err.toString());
});


var source_display, target_display;
var clickCount = 0;
var sourceMarker, targetMarker;
var line;

source_display = document.getElementById("source_dispaly")
target_display = document.getElementById("target_display")



async function onMapClick(e) {
    console.log("hello_entered_the_func")
    clickCount++;

    var lat = e.latlng.lat;
    var lng = e.latlng.lng;

    if (clickCount % 2 === 1) {
        document.getElementById('source-latitude').value = lat;
        document.getElementById('source-longitude').value = lng;

        source_display.innerHTML = await details(lat, lng);

        // הוספת סמן (Marker) לנקודת המוצא
        if (sourceMarker) {
            map.removeLayer(sourceMarker);
        }
        sourceMarker = L.marker([lat, lng]).addTo(map).bindPopup("מוצא").openPopup();

    } else if (clickCount % 2 === 0) {
        document.getElementById('target-latitude').value = lat;
        document.getElementById('target-longitude').value = lng;

        //SendMissile(); //**************** */

        target_display.innerHTML = await details(lat, lng);

        // הוספת סמן (Marker) לנקודת היעד
        if (targetMarker) {
            map.removeLayer(targetMarker);
        }
        targetMarker = L.marker([lat, lng]).addTo(map).bindPopup("יעד").openPopup();
        if (line) {
            map.removeLayer(line);
        }
        // ציור קו בין הנקודות
        line = L.polyline([
            [sourceMarker.getLatLng().lat, sourceMarker.getLatLng().lng],
            [targetMarker.getLatLng().lat, targetMarker.getLatLng().lng]
        ], { color: 'red' }).addTo(map);
    }
}

map.on('click', onMapClick);

function details(lat, lng) {
    var url = `https://nominatim.openstreetmap.org/reverse?lat=${lat}&lon=${lng}&format=json&addressdetails=1`;
    return fetch(url)
        .then(res => res.json())
        .then(data => {
            if (data.display_name) {
                //console.log(data.display_name);
                return data.display_name;
            }
            else {
                return "פרטי השטח לא נמצאו, נראה שבחרתם נקודה בים..."
            }
        });
}