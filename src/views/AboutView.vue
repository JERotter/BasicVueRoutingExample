<template>
  <v-app>
    <Navibar/>
    <v-content>
      <h1>This is an about page</h1>
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
