<template>
  <div class="oneVault">
    <div class="row">
      <div class="col-12 d-flex justify-content-center">
        <h1>{{currentVault.name}}</h1>
        <div class="row">
          <div class="card col-3 m-3 p-3" v-for="keep in keeps">
            <h5><b>{{keep.name}}</b></h5>
            <img :src="keep.img">
            <h6 class="card-font"><b>Views</b>:{{keep.views}}
              <b>Saves</b>:{{keep.keeps}}</h6>
            <button @click="deleteVaultKeep(currentVault.id, keep.id)" class="btn btn-danger btn-sm">Peel from Book</button>
          </div>
        </div>
      </div>
    </div>
  </div>
  </div>
</template>

<script>
  export default {
    name: 'vault',
    data() {
      return {

      }
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      currentVault() {
        return this.$store.state.currentVault
      },
      keeps() {
        return this.$store.state.vaultKeeps
      },
      vaults() {
        return this.$store.state.vaults
      },
      vault() {
        return this.$store.state.vault
      }
    },
    mounted() {
      this.$store.dispatch("currentVault", this.$route.params.vaultId)
      // this.$store.dispatch("getMyKeeps", this.$route.params.vaultId)
    },
    methods: {
      deleteVaultKeep(currentVaultId, keepId) {
        let payload = {
          vaultId: currentVault.id,
          keepId: keepId,
          // userId: this.$store.state.user.id
        }
        this.$store.dispatch("deleteVaultKeep", payload)
      }
    },
    components: {
    }
  }
</script>

<style>
</style>