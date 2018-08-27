var json =
{
	"moto":
	[
		{"marca":"Zanella",
		 "modelo":
			[
				{"nombre":"ZB110"},
				{"nombre":"RX150"}
			]
		},
		{"marca":"Honda",
		 "modelo":
		 	[
		 		{"nombre":"Wava 110 S"},
		 		{"nombre":"CG150 Titan"}
		 	]

		},
		{"marca":"Motomel",
		 "modelo":
		 	[
		 		{"nombre":"B110"},
		 		{"nombre":"CX150"}
		 	]

		}

	]
};

var d = '<tr>'+
'<th>Marca</th>'+
'<th>Modelos</th>'+
'</tr>';

$(function () {
 for (var i = 0; i < json.moto.length; i++) {
 	d+= '<tr>'+ '<td>'+ json.moto[i].marca+'</td>';
 	d+= '<td>';
 for (var j =0; j< json.moto[i].modelo.length;j++)
 {
 	d+= '<p>'+ json.moto[i].modelo[j].nombre+'</p>';
 }
 	d+=	'</td>';
	d+= '</tr>';
 }
 $("#tabla").append(d);
});