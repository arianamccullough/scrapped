<template>
  <div class="col-6 addVault">
    <form class="mt-5" @submit.prevent="addVault">
      <div class="form-group">
        <label for="addVault" class="formfont">Start a New Book</label>
        <input type="text" name="name" class="form-control" v-model="newVault.name" placeholder="Name..." autofocus
          required>
        <input type="text" name="description" class="form-control my-1" v-model="newVault.description" placeholder="Description..."
          required>
        <!-- <input type="number" name="location" class="form-control" v-model="newVault.location" placeholder="Location..." required> -->

        <button type="submit" @click="addVault" class="btn btn-success btn-sm">Add Book</button>
      </div>
    </form>
  </div>
</template>

<script>
  export default {
    name: 'dashformvault',
    data() {
      return {
        newVault: {
          name: '',
          description: ''
          // location: ''
        },
      }
    },
    computed: {},
    methods: {
      addVault() {
        this.$store.dispatch("addVault", this.newVault)
      }
    }
  }
</script>

<style>
  .formfont {
    font-weight: bold;
    font-size: 20px;
  }
</style>