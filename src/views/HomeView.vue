<template>
  <v-app>

  <Navibar/>

    <v-content>

      <v-card width="500" class="mx-auto mt-9">

      <v-divider></v-divider>

        <v-card-actions>

          <v-btn color="success"><router-link to="/login">LOGIN</router-link></v-btn>

          <v-divider></v-divider>

          <v-btn color="info"><router-link to="/create">CREATE ACCOUNT</router-link></v-btn>

        </v-card-actions>

      </v-card>

    </v-content>

  </v-app>
</template>

<script>
import Navibar from '../components/Navbar.vue'

export default {
  name: 'Home',
  components: {
    Navibar
  }
}
</script>
