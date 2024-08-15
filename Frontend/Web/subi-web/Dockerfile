# Stage 1: Build the React application
FROM node:14 AS build

ENTRYPOINT []

WORKDIR /app

# Copy package.json and package-lock.json first to leverage Docker cache
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application code
COPY . .

# Build the React app
RUN npm run build

# Stage 2: Serve the React application using Nginx
FROM nginx:alpine

# Copy build output from the 'build' stage
COPY --from=build /app/build /usr/share/nginx/html

# Copy custom Nginx configuration if you have one
COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
