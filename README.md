<h1>RestfulCatApi</h1>

<h2>Introduction</h2>

A RESTful API for tracking Owners and their cats.

<h2>Requirements</h2>

This application requires the user to have .net core installed, as well as a MongoDB database.

<h2>Important endpoints</h2>

GET api/owners
This returns all of the owners and their cats

POST api/owners
This allows you to create an owner with cats. Example body:
{
	"name": "Mildred",
	"age": 50,
	"myCats": [
		{
			"name": "Jojo",
			"age": 15,
			"type": "Tortoiseshell"
		}
	]
}