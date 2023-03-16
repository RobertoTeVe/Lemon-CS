# Azure Deploy

Following summary is a step by step guide on how to deploy an App using Azure services. This App wil be hosted in the cloud for which Azure has many functionalities that allows us, for example, to know where our App is running slow. 

---

## Prerequisites

Things to have:
- Frontend App
- Backend App
- Azure Subscription
- Azure Data Studio downloaded (used to access to Azure SQL)
- (Optional) VS Code with Azure extension
- (Optional) Microsoft Azure Storage Explorer downloaded (used to access our Storage Account)

---

## Deploy App

### 1. Create Azure Storage Service

First, one must create the service:

- Go to the service: Storage Accounts
- Click "Create" (Top-left side of the screen)
    - Select the 'Subscription' that you'll be using to host the App
    - Select 'Resource group' that you'll be using to host the App
    - Create a name for the storage account: all lowercase
    - Set region (should match all the other services)
    - Set 'Performance' as 'Standard'
    - Set "Redundancy" as local (LRS), which is enough for this excercise
    - Leftover values can be left unchanged

Once the Storage Account is created, one must configure it. Head on to the storage and in the left column of options: 
- Search for 'Data Storage'
- There you'll find 'Containers', which it is going to be where our images will be stored
    - These should be created as 'Blobs'
    - Create as much as you need, for example: 'Games' and 'Screenshots'


Then, you'll need to save the connection string and save it to the clipboard for later use.


### 2. Create Azure SQL Service

Process is similar to the previous service:

- Go to the service: Azure SQL
- Click "Create" (Top-left side of the screen)
    - Select SQL Database
    - Set it as 'Single database'
    - Click 'Create'
    - Select the 'Subscription' that you'll be using to host the App
    - Select 'Resource group' that you'll be using to host the App
    - Type name for the Database 
    - Set region (should match all the other services)
    - Compute + storage: set it to Standard S0, cheapest and enough for this project
    - Set 'Backup Storage Redundancy' as 'Locally-redundant backup storage'
    - Leftover values can be left untouched

Now that that we create the service, we can access it from the Azure Data Studio desktop app. There we'll be able to create the neccesary tables and entries. I needed to create 'Game' and 'Screenshots' (with some premade SQL scripts found at: ../db/).


### 3. Deploy API (App Services)

Now that we created the storage service, we must change our connection string in code before going on with the deployment.
After doing it, lets upload our API:

- Go to the service: App Services
- Click "Create" (Top-left side of the screen)
    - Select the 'Subscription' that you'll be using to host the App
    - Select 'Resource group' that you'll be using to host the App
    - Type name for the App Service: all lowercase
    - Select how you want to publish it: by Code, Docker Container or Static Wep App
    - Select Runtime Stack (.NET 6, in this case)
    - Set region (should match all the other services)
    - Select pricing plan, in this case the cheapest
    - Select from which you are going to deploy it (in this case GitHub)
    - GitHub deployment can be activated 
        - Select Organization, Repository and Branch
    - Leftover values can be left unchanged



### 4. Deploy Frontend (Static Web App)

And with our API working, it's time for the Frontend. We must change the connection string, now pointing out to our App Service in Azure.
Then:

- Go to the service: Static Web Apps
- Click "Create" (Top-left side of the screen)
    - Select the 'Subscription' that you'll be using to host the App
    - Select 'Resource group' that you'll be using to host the App
    - Type name for the resource
    - Select the 'Hosting Plan', in this case the Free option should be more than enough
    - Set region (should match all the other services)
    - Select from which you are going to deploy it (in this case GitHub)
        - Select Organization, Repository and Branch
    - Leftover values can be left untouched


### 5. Link services (Permissions and CORS)

Permissions between services should be granted so all can communicate and share data throughout. To achive that, you should go to all the neccesary services, inside "Access control (IAM)" and add role assignment:

- Select the role: you could give specific ones depending on the services, as a rule of thumb, between services, you could set it as "Contributor"
- Select the member to which you want to give that role: In this case you should check "Managed identity" and select the service you want from your subscription

Also it's a source of problems not configuring CORS. Same as before, go to all the neccesary services and scroll down to "Resource sharing (CORS)" or simply "CORS" and: 

- Here you'll allow specific origins or all origins. 
    - For the first just type the origin for which you want to grant access
    - For the second type '*', without single quotes
- Also it's important to set the methods allowed, in my case all of them


---

## Delete related blobs - Theory

Now that our App is working, it's time to delete images using Azure services.

### 1. Basic

The easiest and fastest approach is by using a call to a method in our code. 
Simply make so when you call 'DeleteGame' in yout API, this access the Storage Account and delets wherever ID is passed through the URL.
By also connecting to the Azure SQL, you can also delete all those images related because the table has the 'game ID' column. 


### 2. Medium

The previous way can work for small images and when there's not many being deleted. Otherwise, our App will run slowly, that's why we should change our approach:

- First we will need to create a Function App
    - Head on to that service and create a new one, configure it as always (Subscription, Resource, etc.)
- Now go to your Storage Account.
- Search for the 'Events' tab in the left column and add a new one
    - Configure all neccesary parameters
    - Set the 'Endpoint Type' to 'Azure Functions' and select your previously created Function App as 'Endpoint'
- Now the programming that we performed in the previous way should be changed into these functions.