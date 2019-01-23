<template>
  <div class="dashboard">
    <h2>My Vaults</h2>
    <div class="col-12 d-flex justify-content-center">
      <div class="card addVault-card">
        <form @submit.prevent="addVault">
          <div class="form-group px-2">
            <h5 class="white-text">Create a New Vault</h5>
            <input type="text" placeholder="Vault Title..." v-model="newVault.name" class="form-control" autofocus
              required>
            <input type="text" placeholder="Description..." v-model="newVault.description" class="form-control">
            <!-- <input type="number" placeholder="Zip..." v-model="newVault.location" class="form-control"> -->

            <button type="submit" class="createVault">Add <i class="fas fa-plus fas-3x"></i></button>
          </div>
        </form>
      </div>
    </div>
    <div class="row">
      <div v-for="vault in vaults" :key="vault.id" class="col-4">
        <div class="card">
          <router-link :to="{name: 'onevault', params: {vaultId: vault.id}}">
            <h5>{{vault.title}}</h5>
            <p>{{vault.description}}</p>
          </router-link>
          <button @click="deleteVault(vault.id)">DELETE <i class="fas fa-trash-alt fas-3x"></i></button>

        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import vault from '@/components/Vault.vue'

  export default {
    name: "dashboard",

    data() {
      return {
        newVault: {
          name: "",
          description: "",
          // location: ""
        }
      };
    },
    mounted() {
      // this.$store.dispatch('authenticate')
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
        // this.$store.dispatch("getVaults")
      }
    },
    components: {
      vault
    },
    computed: {
      vaults() {
        return this.$store.state.vaults || []
      }
    },
    methods: {
      addVault() {
        this.$store.dispatch("addVault", this.newVault);
        this.newVault = { name: "", description: "" };
      },
      deleteVault(vaultId) {
        this.$store.dispatch("deleteVault", vaultId);
      }
    }
  };
</script>

<style scoped>

</style>