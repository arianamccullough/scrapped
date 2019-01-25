<template>
  <div class="allVaults">
    <div class="row">
      <div class="col-12">
        <h3>My Books</h3>
      </div>
      <div class="col-3 card p-3 m-3" v-for="vault in vaults">
        <h5 class="card-font"><b>{{vault.name}}</b></h5>
        <p class="card-font pb-3"><i>{{vault.description}}</i></p>
        <!-- <p>{{vault.location}}</p> -->
        <router-link :to="{name: 'vault', params: {vaultId: vault.id}}" class="pb-2">
          <button class="btn btn-info btn-sm">View This Book</button>
        </router-link>
        <button class="btn btn-danger btn-sm" @click="deleteVault(vault.id)">Recycle Book</button>
      </div>
    </div>
  </div>
  </div>
</template>

<script>
  export default {
    name: 'vaults',
    mounted() {
      this.$store.dispatch("getVaults")
    },
    data() {
      return {
      }
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      deleteVault(id) {
        this.$store.dispatch("deleteVault", id)
      }
    }
  }
</script>

<style scoped>
  .card {
    outline: 1px solid black;
  }

  .card:hover {
    outline: 1px solid black;
    box-shadow: 3px 3px rgb(185, 185, 185);
  }

  .card-font {
    color: black;
  }

  a {
    color: black;
    cursor: pointer;
  }

  a:hover {
    color: rgb(255, 253, 109);
  }
</style>