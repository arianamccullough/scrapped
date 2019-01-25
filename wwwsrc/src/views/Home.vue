<template>
  <div class="home">
    <div class="container-fluid">
      <h2>Welcome to Scrapped!</h2>
      <div class="col-12">
        <div class="row">
          <div class="card col-3 p-3 m-3" v-for="keeps in allKeeps">
            <h5><b>{{keeps.name}}</b></h5>
            <router-link :to="{name: 'keep', params: {keepId: keeps.id}}">
              <img :src="keeps.img">
            </router-link>
            <button class="btn btn-info btn-sm">
              <router-link :to="{name: 'keep', params: {keepId: keeps.id}}">View This Scrap</router-link>
            </button>
            <h6 class="card-font"><b>Views</b>:{{keeps.views}}
              <b>Pastes</b>:{{keeps.saves}}</h6>
            <div class="dropdown" v-show="user.id">
              <button class="btn btn-info btn-sm dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown">Paste
                To...</button>
              <div class="dropdown-menu">
                <p class="dropdown-item" v-for="vault in vaults" @click="addVaultKeep(vault.id, keeps)">{{vault.name}}</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "home",
    mounted() {
      this.$store.dispatch("getHomeKeeps")
    },
    data() {
      return {
      }
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      allKeeps() {
        return this.$store.state.allKeeps
      },
      vaults() {
        return this.$store.state.vaults
      },
      vault() {
        return this.$store.state.vault
      }
    },
    methods: {
      addVaultKeep(vaultId, keep) {
        let vaultKeep = {
          vaultId: vaultId,
          keepId: keep.id,
          userId: this.user.id
        }
        keep.keeps++
        this.$store.dispatch("updateKeep", keep)
        this.$store.dispatch("addVaultKeep", vaultKeep)
      },
    }
  };
</script>

<style scoped>
  img {
    width: 100%;
    height: 150px;
  }

  .card-font {
    color: black;
  }

  .card {
    outline: 1px solid black;
    ;
  }

  .card:hover {
    outline: 1px solid black;
    box-shadow: 3px 3px black;
  }

  a {
    color: white;
    cursor: pointer;
  }

  a :hover {
    color: rgb(255, 253, 109);
  }
</style>