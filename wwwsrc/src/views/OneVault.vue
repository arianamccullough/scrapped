<template>
  <div class="onevault">

    <vault :vault="vault"></vault>
    <div v-for="keep in keeps">
      <keep :keep="keep"></keep>
    </div>

  </div>
</template>

<script>
  import vault from '@/components/Vault.vue'
  import keep from '@/components/Keep.vue'

  export default {
    name: 'onevault',
    mounted() {
      // this.$store.dispatch("authenticate")
      this.$store.dispatch("getVault", this.$route.params.vaultId)

    },
    data() {
      return {
      }
    },

    components: {
      vault,
      keep
    },
    computed: {
      vault() {
        return this.$store.state.vault
      },
      vaults() {
        return this.$store.state.vaults
      },
      keeps() {
        return this.$store.state.keeps || []
      }
    },
    methods: {
      getKeeps() {
        this.$store.dispatch('getKeeps', this.keeps)
      },
    }
  }

</script>

<style>


</style>