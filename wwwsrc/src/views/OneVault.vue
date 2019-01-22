<template>
  <div class="onevault">

    <vault :vault="vault"></vault>

  </div>
</template>

<script>
  import vault from '@/components/Vault.vue'

  export default {
    name: 'onevault',
    mounted() {
      // this.$store.dispatch("authenticate")
      if (!this.vaults.length) {
        this.$store.dispatch("getVault", this.$route.params.vaultId)
      }

    },
    data() {
      return {
      }
    },

    components: {
      vault
    },
    computed: {
      vault() {
        return this.$store.state.vault
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {

    }
  }

</script>

<style>


</style>