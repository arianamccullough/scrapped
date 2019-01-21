<template>
  <div id="app">
    <nav class="navbar navbar-default row">
      <div class="col-3 d-flex justify-content-start">
        <router-link :to="{name: 'dashboard'}">
          Go to Dashboard
        </router-link>
      </div>
      <div class="col-4 d-flex justify-content-start">
        <router-link :to="{name: 'home'}">
          Go Home
        </router-link>
      </div>
      <div class="col-3 web-title justify-content-center">
        <h1>Keepr</h1>
      </div>
      <div class="col-3 d-flex justify-content-end">
        <button @click="logout">Logout</button>
      </div>
    </nav>
    <router-view />
  </div>

</template>
<script>
  export default {
    methods: {
      logout() {
        this.$store.dispatch('logout')
      },

    }
  }
</script>


<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }
</style>