<template>
  <v-app>
    <v-app-bar app color = "blue">
      <v-toolbar-title>Welcome to LiftOff Fitness!</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn text rounded><router-link to="/">Home</router-link></v-btn>
      <v-btn text rounded><router-link to="/contact">Contact Us</router-link></v-btn>
      <v-btn text rounded><router-link to="/about">About</router-link></v-btn>
    </v-app-bar>
  </v-app>
</template>
