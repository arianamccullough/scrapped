<template>
  <div class="vault">
    <h4><b>{{vault.name}} </b></h4>
    <p><i>{{vault.description}}</i></p>
    <!--<div class="row">
      <div class="col-6">
         <router-link :to="{name: 'onekeep'}">
          <button @click="makeTargetKeep(keepId)">
            View Keep
          </button>
        </router-link>
      </div>
       <div class="col-6">
        <div class="dropdown">
          <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
            aria-haspopup="true" aria-expanded="false">
            Save Keep To... </button>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
     <p v-for="keep in keeps" @click="saveKeep(vault.id)">{{vault.name}}</p> 
      </div>
        </div>
      </div>
    </div> -->
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

    },

    props: ['vault'],

    methods: {
      makeTargetVault() {
        this.$router.push({ name: "onevault", params: { vaultId: this.vault.id } })
        this.$store.dispatch("makeTargetVault", this.vault)
      },
      deleteVault() {
        this.$store.dispatch('deleteVault', this.vault)
      },

    }
  }
</script>