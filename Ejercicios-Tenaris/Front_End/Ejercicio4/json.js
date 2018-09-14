$( document ).ready(function() {


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



var motos = [];

//------------------------------------------------------------------------------------------------------
var zanella = new Object();
zanella.marca = "Zanella";
zanella.modelo = [];

var modeloZanellaZB110 = new Object();
modeloZanellaZB110.nombre= "ZB110";
modeloZanellaZB110.velocidadMax= 300;
var modeloZanellaRX150 = new Object();
modeloZanellaRX150.nombre = "RX150";
modeloZanellaRX150.velocidadMax=250;

zanella.modelo.push(modeloZanellaZB110);
zanella.modelo.push(modeloZanellaRX150);

//---------------------------------------------------------------------------------------------------------

var honda = new Object();
honda.marca = "Honda";
honda.modelo= [];

var modeloHondaWava110S = new Object();
modeloHondaWava110S.nombre= "Wava 110 S";
modeloHondaWava110S.velocidadMax = 325;
var modeloHondaCG150Titan = new Object();
modeloHondaCG150Titan.nombre = "CG150 Titan";
modeloHondaCG150Titan.velocidadMax = 225;

honda.modelo.push(modeloHondaWava110S);
honda.modelo.push(modeloHondaCG150Titan);

//----------------------------------------------------------------------------------------------------------

var motomel = new Object();
motomel.marca = "Motomel";
motomel.modelo = [];

var modeloMotomelB110 = new Object();
modeloMotomelB110.nombre= "B110";
modeloMotomelB110.velocidadMax = 275;
var modeloMotomelCX150 = new Object();
modeloMotomelCX150.nombre = "CX150";
modeloMotomelCX150.velocidadMax = 175;

motomel.modelo.push(modeloMotomelB110);
motomel.modelo.push(modeloMotomelCX150);

//----------------------------------------------------------------------------------------------------------

motos.push(zanella);
motos.push(honda);
motos.push(motomel);


var json1 = JSON.stringify(motos);

 $('#json').append("El json se ve:");
 $('#json').append(json1);

//---------------------------------------------------------------------------------------------------------

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

});