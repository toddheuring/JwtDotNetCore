# JWT Example On a .NET Core Api

**Create Jwt With Id Claim**
----

* **URL**

    http://localhost:5000/api/jwt

* **Method:**
  
  `POST`

* **Data Params**

  Body takes in a single string for an `id` that is used to add as claim in the jwt

* **Success Response:**
  
  * **Code:** 200 <br />
    **Content:** `{"status": "success", "token": "jwtToken"}`
 
* **Error Response:**

  * **Code:** 500 Internal Server Error

**Validate and Refresh Token**
----

* **URL**

    http://localhost:5000/api/jwt

* **Method:**
  
  `GET`

* **Header Params**

  Takes in a Bearer Authorization header with the jwt acquired from the above

* **Success Response:**
  
  * **Code:** 200 <br />
    **Content:** `{"status": "success"}` <br/>
    **Headers:** response Authorization header will be updated with a new time-out

* **Error Response:**

  * **Code:** 500 Internal Server Error