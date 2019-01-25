<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <dashformvault></dashformvault>
      <dashformkeep></dashformkeep>
    </div>
    <vaults></vaults>
    <myKeeps></myKeeps>
  </div>
</template>

<script>
  import vaults from "@/components/Vaults.vue"
  import dashformkeep from "@/components/DashFormKeep.vue"
  import dashformvault from "@/components/DashFormVault.vue"
  import myKeeps from "@/components/MyKeeps.vue"
  export default {
    name: 'Dashboard',
    data() {
      return {
      }
    },
    computed: {
    },
    mounted() {
      this.$store.dispatch("authenticate");
    },
    methods: {},
    components: {
      vaults,
      dashformkeep,
      dashformvault,
      myKeeps
    }
  }
</script>

<style>
  a:link {
    color: white;
    cursor: pointer;
  }

  a :hover {
    color: rgb(255, 253, 109);
  }
</style>