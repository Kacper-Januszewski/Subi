# Use the official Node.js image as the base image
FROM node:18 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy package.json and package-lock.json to the container
COPY package.json package-lock.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application code to the container
COPY . .

# Build the React app
RUN npm run build

# Stage 2: Serve the application using an nginx server
FROM nginx:alpine

# Copy the built app from the build stage to nginx's default static directory
COPY --from=build /app/build /usr/share/nginx/html

# Expose the default port nginx uses
EXPOSE 80

# Override the entrypoint to start nginx
ENTRYPOINT ["nginx", "-g", "daemon off;"]

# Start nginx
#CMD ["nginx", "-g", "daemon off;"]