<template>
  <div v-if="vault.name" class="myVault">
    <div class="row">
      <div class="col-12">
        <h2>{{vault.name}}</h2>
        <p><i>{{vault.description}}</i></p>
        <p>{{vault.location}}</p>
      </div>
    </div>

    <div class="row">
      <div v-for="keepData in keeps" class="col-12">
        <keep :keep="keepData"></keep>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <form @submit.prevent="addKeep" class="form-group">
          <h5>Add a Keep</h5>
          <input v-model="newKeep.name" type="text" name="name" placeholder="Name..." class="mx-2" />
          <input v-model="newKeep.description" type="text" name="description" placeholder="Description..." class="mx-2" />
          <input v-model="newKeep.img" type="url" name="img" placeholder="Image..." class="mx-2" />
          <button type="submit"> + New Keep</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
  import keep from '@/components/Keep.vue'
  export default {
    name: "keep",
    data() {
      return {
        newKeep: {
          name: '',
          description: '',
          img: '',
          vaultId: ''
        }
      }

    },
    created() {
      this.$store.dispatch('getMyKeeps', this.$route.params.keepId)
    },
    mounted() {
    },
    computed: {
      vault() {
        return this.$store.state.keeps.find(v => v._id == this.$route.params.vaultId) || {}
      },
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {
      addKeep() {
        this.newKeep.vaultId = this.$route.params.vaultId
        this.$store.dispatch('addKeep', this.newKeep)
      }
    },
    components: {
      keep
    }
  };
</script>
<style>



</style>