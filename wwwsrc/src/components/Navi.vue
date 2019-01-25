<template>
  <div id="navi">
    <div class="topper container-fluid py-3">
      <div class="row">
        <div class="col-4 d-flex justify-content-start">
          <router-link :to="{name: 'dashboard'}">
            <h6>My Dashboard</h6>
          </router-link>
        </div>
        <div class="col-4 d-flex justify-content-center">
          <router-link :to="{name: 'home'}">
            <h3>Scrapped!</h3>
          </router-link>
        </div>

        <!-- <li class="nav-item">
          <a class="nav-link" href="#/login" v-if="!user.id">Login</a>
          <a class="nav-link" href="#/login" v-else @click="logout">Logout</a>
        </li> -->

        <div class="col-4 d-flex justify-content-end">
          <div v-if="!user.id">
            <router-link :to="{name: 'login'}">
              <h6>Login</h6>
            </router-link>
          </div>
          <div v-else>
            <h6 @click="logout">Logout</h6>
          </div>
        </div>




      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'navi',
    data() {
      return {
      }
    },
    mounted() {
      this.$store.dispatch("authenticate")
    },

    computed: {
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout")
      },
      login() {
        this.$store.dispatch("login")
      }
    },
  }

</script>

<style>
  .topper {
    background-color: rgb(13, 2, 97);

  }

  a:link {
    color: white;
    cursor: pointer;
  }

  a :hover {
    color: rgb(255, 253, 109);
  }
</style>