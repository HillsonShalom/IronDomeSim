//var map = L.map('map').setView([31.0461, 34.8516], 8); // ישראל
//L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
//    maxZoom: 19,
//}).addTo(map);

var connection = new signalR.HubConnectionBuilder().withUrl("/hub").build();
connection.on("Radar", function (model, seconds, src_lat, src_lng, dst_lat, dst_lng) {
    console.log("נכנס")
    let weapon = JSON.parse(model);
    let src_display = await GetLocationDisplay(src_lat, src_lng);
    let dst_display = await GetLocationDisplay(dst_lat, dst_lng);
    console.log(src_display)
    console.log(dst_display)
    addNotification(weapon.Name, seconds, src_display, dst_display);

    var sourceMarker, targetMarker;
    var line;

    if (sourceMarker) {
        map.removeLayer(sourceMarker);
    }
    sourceMarker = L.marker([src_lat, src_lng]).addTo(map).bindPopup("מוצא").openPopup();

    if (targetMarker) {
        map.removeLayer(targetMarker);
    }
    targetMarker = L.marker([dst_lat, dst_lng]).addTo(map).bindPopup("יעד").openPopup();
    if (line) {
        map.removeLayer(line);
    }
    // ציור קו בין הנקודות
    line = L.polyline([
        [sourceMarker.getLatLng().lat, sourceMarker.getLatLng().lng],
        [targetMarker.getLatLng().lat, targetMarker.getLatLng().lng]
    ], { color: 'red' }).addTo(map);
});

connection.start().then(function () {
    console.log("SignalR connected");
}).catch(function (err) {
    return console.error(err.toString());
});

function addNotification(name, time, src, dst) {
    let element = document.createElement("div");
    element.classList.add("notification");
    let notification_name = document.createElement("h3");
    notification_name.innerHTML = name;
    let notification_time = document.createElement("h4");
    notification_time.innerHTML = time;
    let notification_src = document.createElement("p");
    notification_src.innerHTML = src;
    let notification_dst = document.createElement("p");
    notification_dst.innerHTML = dst;
    element.appendChild(notification_name);
    element.appendChild(notification_time);
    element.appendChild(notification_src);
    element.appendChild(notification_dst);
    console.log("יצרתי אלמנט")
}

async function GetLocationDisplay(lat, lng) {
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
