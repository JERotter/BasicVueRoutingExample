<template>
  <v-app>

  <Navibar/>

    <v-content>

      <v-card width="500" class="mx-auto mt-9">

      <v-card-title>Log In</v-card-title>

      <v-card-text>

      <v-text-field label="Email Address" type="email" prepend-icon="mdi-account-circle"></v-text-field>

      <v-text-field label="Password" type="password" prepend-icon="mdi-lock" append-icon="mdi-eye-off"></v-text-field>

      </v-card-text>

      <v-divider></v-divider>

      <v-card-actions>

      <v-btn color="success">LOGIN</v-btn>

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
